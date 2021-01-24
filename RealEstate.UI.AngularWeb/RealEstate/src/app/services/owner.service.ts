import {HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Owner } from '../models/owner';

@Injectable()
export class OwnerService{
    constructor(private http: HttpClient) { }

    create(owner: Owner) {
        return this.http.post<Owner>(environment.apiBaseUrl + 'owners/create', owner);
    }

    update(owner: Owner) {
        return this.http.put<Owner>(environment.apiBaseUrl + 'owners', owner);
    }

    getById(ownerId: number) {
        return this.http.get<Owner>(environment.apiBaseUrl + 'owners/'+ownerId);
    }  

    getAll() {
        return this.http.get<Owner[]>(environment.apiBaseUrl + 'owners/');
    }    

    delete(id: number) {
        return this.http.delete<boolean>(environment.apiBaseUrl + 'owners/' + id);
    }

}