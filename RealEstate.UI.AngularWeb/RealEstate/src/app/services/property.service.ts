import {HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Property } from '../models/property';

@Injectable()
export class PropertyService{
    constructor(private http: HttpClient) { }

    create(property: Property) {
        return this.http.post<Property>(environment.apiBaseUrl + 'properties/', property);
    }

    update(property: Property) {
        return this.http.put<Property>(environment.apiBaseUrl + 'properties/'+property.id, property);
    }

    getById(propertyId: number) {
        return this.http.get<Property>(environment.apiBaseUrl + 'properties/'+propertyId);
    }  

    getAll() {
        return this.http.get<Property[]>(environment.apiBaseUrl + 'properties/');
    }    

    delete(id: number) {
        return this.http.delete<boolean>(environment.apiBaseUrl + 'properties/' + id);
    }

}