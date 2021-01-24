import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Property, PropertyCategory } from '../../models';
import { PropertyService } from '../../services/property.service';

@Component({
    selector: 'app-create-property',
    templateUrl: './create-property.component.html',
    //styleUrls: ['./create-property.component.scss']
})
export class CreatePropertyComponent implements OnInit {
    property: Property;
    categories: PropertyCategory[];
    loading: boolean;
    mode: string = '';
    propertyId: number;

    constructor(private propertyService: PropertyService,
        private activeRoute: ActivatedRoute) { }

    ngOnInit() {
        this.loading = false;
        this.property = new Property();

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
                    //this.toastr.error(error.error.Message, "Error obteniendo información para la propiedad con id " + this.propertyId);
                });
        }
        this.getCategories();
    }

    getCategories() {
        // this.propertyCategoryService.getRoles().subscribe(
        //     data => {
        //         this.loading = false;
        //         this.categories = data;
        //     },
        //     error => {
        //         this.loading = false;
        //         //this.toastr.error(error.error.Message, "Error obteniendo lista de categorias.");
        //     });
    }


    create(form: NgForm) {
        this.loading = true;
        if (this.mode == 'edit') {
            this.propertyService.update(this.property).subscribe(
                data => {
                    this.loading = false;
                    //this.toastr.success("Propiedad actualizado!!!");
                },
                error => {
                    this.loading = false;
                    //this.toastr.error(error.error.Message, "Error");
                });
        }
        else if (this.mode == 'new') {
            this.propertyService.create(this.property)
                .subscribe(
                    data => {
                        this.loading = false;
                        //this.toastr.success("Propiedad creado!!!");
                        form.resetForm();
                    },
                    error => {
                        this.loading = false;
                        //this.toastr.error(error.error.message, "Error");
                    });
        }
    }
}

