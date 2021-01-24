import { Component, OnInit } from '@angular/core';
import { OwnerService } from '../../services/owner.service';
import { Owner } from '../../models/';

@Component({
    selector: 'app-owners',
    templateUrl: './owner.component.html',
    //styleUrls: ['./owner.component.scss']
})
export class OwnersComponent implements OnInit {
    owners: Owner[];

    constructor(private ownerService: OwnerService) { }

    ngOnInit() {
        this.getOwners();
    }

    getOwners() {
        this.ownerService.getAll().subscribe(
            data => {
                this.owners = data;
            },
            error => {
                //this.toastr.error(error.error.Message, "Error obteniendo lista de propietarios.");
            });
    }

    delete(owner: Owner) {
        if (confirm("Seguro desea eliminar el propietario " + owner.firstName + "?.")) {
            this.ownerService.delete(owner.id).subscribe(
                data => {
                    //this.toastr.success("Registro eliminado.");
                    this.getOwners();
                },
                error => {
                    //this.toastr.error(error.error.Message, "Error eliminando el registro.");
                });
        }
    }
  
}
