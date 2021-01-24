import { Component, Input, OnInit  } from '@angular/core';
import {NgForm} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CityService } from 'src/app/services/city.service';
import { PropertyCategoryService } from 'src/app/services/propertyCategory.service';
import { City, Property, PropertyCategory } from '../../models';
import { PropertyService } from '../../services/property.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NoopAnimationPlayer } from '@angular/animations';

@Component({
    selector: 'app-create-property',
    templateUrl: './create-property.component.html',
    // styleUrls: ['../../../styles.css']
})
export class CreatePropertyComponent implements OnInit {
    property: Property;
    categories: PropertyCategory[];
    cities:City[];
    loading: boolean;
    mode: string = '';
    private _propertyId: number;
    private _readOnly: boolean;

    constructor(private propertyService: PropertyService,
        private propertyCategoryService: PropertyCategoryService,
        private cityService: CityService,
        private activeRoute: ActivatedRoute,
        private toastr: ToastrService,
        public activeModal: NgbActiveModal) { }

    @Input()
    set propertyId(propertyId: number) {        
        this._propertyId = propertyId;
    }        

    @Input()
    set readOnly(readOnly: boolean) {        
        this._readOnly = readOnly;
        if(this._readOnly && this._readOnly==true){
            this.mode = 'view';
        }
    }  
    
    ngOnInit() {
        this.loading = false;
        this.property = new Property();
       
        this.activeRoute.params.subscribe(params => {
            if (!this._propertyId) {
                if (params['id'] && this._readOnly==true) {
                    this.mode = 'view';
                    this._propertyId = params['id'];
                }
                else if (params['id']) {
                    this.mode = 'edit';
                    this._propertyId = params['id'];
                }
                else {
                    this.mode = 'new';
                }
            }
        });

        if (this.mode != 'new') {
            this.loading = true;
            this.propertyService.getById(this._propertyId).subscribe(
                result => {          ;
                    this.loading = false;
                    this.property = result["data"];
                },
                error => {
                    this.loading = false;
                    this.toastr.error(error.error.Message, "Error obteniendo información para la propiedad con id " + this._propertyId);
                });
        }
        this.getCategories();
        this.getCities();
    }

    getCategories() {
        this.propertyCategoryService.getPropertyCategories().subscribe(
            result => {
                this.loading = false;
                this.categories = result["data"];
            },
            error => {
                this.loading = false;
                this.toastr.error(error.error.Message, "Error obteniendo lista de categorias.");
            });
    }

    getCities() {
        this.cityService.getCities().subscribe(
            result => {
                this.loading = false;
                this.cities = result["data"];
            },
            error => {
                this.loading = false;
                this.toastr.error(error.error.Message, "Error obteniendo lista de ciudades.");
            });
    }

    create(form: NgForm) {
        console.log(this.property);
        this.loading = true;
        if (this.mode == 'edit') {
            this.propertyService.update(this.property).subscribe(
                data => {
                    this.loading = false;
                    this.toastr.success("Propiedad actualizado!!!");
                },
                error => {
                    this.loading = false;
                    this.toastr.error(error.error.Message, "Error");
                });
        }
        else if (this.mode == 'new') {
            this.propertyService.create(this.property)
                .subscribe(
                    data => {
                        this.loading = false;
                        this.toastr.success("Propiedad creado!!!");
                        form.resetForm();
                    },
                    error => {
                        this.loading = false;
                        this.toastr.error(error.error.message, "Error");
                    });
        }
    }
}

