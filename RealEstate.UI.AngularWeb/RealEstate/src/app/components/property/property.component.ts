import { Component, OnInit } from '@angular/core';
import { PropertyService } from '../../services/property.service';
import { Property } from '../../models/';

@Component({
    selector: 'app-properties',
    templateUrl: './property.component.html',
    //styleUrls: ['./property.component.scss']
})
export class PropertiesComponent implements OnInit {
    properties: Property[];

    constructor(private propertyService: PropertyService) { }

    ngOnInit() {
        this.getProperties();
    }

    getProperties() {
        this.propertyService.getAll().subscribe(
            data => {
                this.properties = data;
            },
            error => {
                //this.toastr.error(error.error.Message, "Error obteniendo lista de propiedades.");
            });
    }

    delete(property: Property) {
        if (confirm("Seguro desea eliminar la Propiedad " + property.name + "?.")) {
            this.propertyService.delete(property.id).subscribe(
                data => {
                    //this.toastr.success("Registro eliminado.");
                    this.getProperties();
                },
                error => {
                    //this.toastr.error(error.error.Message, "Error eliminando el registro.");
                });
        }
    }
  
}
