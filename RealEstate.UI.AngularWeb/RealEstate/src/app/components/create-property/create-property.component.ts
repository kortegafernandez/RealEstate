import { Component, OnInit, Input  } from '@angular/core';
import {NgForm} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CityService } from 'src/app/services/city.service';
import { PropertyCategoryService } from 'src/app/services/propertyCategory.service';
import { City, Property, PropertyCategory } from '../../models';
import { PropertyService } from '../../services/property.service';
import { ToastrService } from 'ngx-toastr';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-create-property',
    templateUrl: './create-property.component.html',
    // styleUrls: ['../../../styles.css']
})
export class CreatePropertyComponent implements OnInit {
    @Input() name;

    property: Property;
    categories: PropertyCategory[];
    cities:City[];
    loading: boolean;
    mode: string = '';
    propertyId: number;

    constructor(private propertyService: PropertyService,
        private propertyCategoryService: PropertyCategoryService,
        private cityService: CityService,
        private activeRoute: ActivatedRoute,
        private toastr: ToastrService,
        public activeModal: NgbActiveModal) { }

    ngOnInit() {
        this.loading = false;
        this.property = new Property();
        console.log(this.property);

        this.activeRoute.params.subscribe(params => {
            if (params['id']) {
                this.mode = 'edit';
                this.propertyId = params['id'];
            }
            else {
                this.mode = 'new';
            }
        });

        if (this.mode == 'edit') {
            this.loading = true;
            this.propertyService.getById(this.propertyId).subscribe(
                data => {
                    this.loading = false;
                    this.property = data;
                },
                error => {
                    this.loading = false;
                    this.toastr.error(error.error.Message, "Error obteniendo información para la propiedad con id " + this.propertyId);
                });
        }
        this.getCategories();
    }

    getCategories() {
        console.log("listar categorias");
        this.propertyCategoryService.getPropertyCategories().subscribe(
            data => {
                this.loading = false;
                this.categories = data;
            },
            error => {
                this.loading = false;
                this.toastr.error(error.error.Message, "Error obteniendo lista de categorias.");
            });
    }

    getCities() {
        console.log("listar ciudades");
        this.cityService.getCities().subscribe(
            data => {
                this.loading = false;
                this.cities = data;
            },
            error => {
                this.loading = false;
                this.toastr.error(error.error.Message, "Error obteniendo lista de ciudades.");
            });
    }

    create(form: NgForm) {
        console.log("guardar "+this.mode);
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

