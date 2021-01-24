import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PropertyService } from '../../services/property.service';
import { Property } from '../../models/';
import { CreatePropertyComponent } from '../create-property/create-property.component';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-properties',
    templateUrl: './property.component.html',
    //styleUrls: ['./property.component.scss']
})
export class PropertiesComponent implements OnInit {
    properties: Property[];

    constructor(private propertyService: PropertyService,
        private modalService: NgbModal,        
        private toastr: ToastrService,) { }

    ngOnInit() {
        this.getProperties();
    }
  
    getProperties() {
        this.propertyService.getAll().subscribe(
            result => {
                this.properties = result['data']; 
            },
            error => {
                this.toastr.error(error.error.Message, "Error obteniendo lista de propiedades.");
            });
    }

    delete(property: Property) {
        if (confirm("Seguro desea eliminar la Propiedad " + property.name + "?.")) {
            this.propertyService.delete(property.id).subscribe(
                data => {
                    this.toastr.success("Registro eliminado.");
                    this.getProperties();
                },
                error => {
                    this.toastr.error(error.error.Message, "Error eliminando el registro.");
                });
        }
    }
  
    openModal(propertyId: number,readOnly:boolean) {
        const modalRef = this.modalService.open(CreatePropertyComponent,{ size: 'lg' });
        if (propertyId) {
            modalRef.componentInstance.propertyId = propertyId;            
        }
        if(readOnly==true){
            modalRef.componentInstance.readOnly = readOnly;            
        }
    }
}
