import {HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PropertyCategory } from '../models/propertyCategory';

@Injectable()
export class PropertyCategoryService{
    constructor(private http: HttpClient) { }   

    getPropertyCategories() {
        return this.http.get<PropertyCategory[]>(environment.apiBaseUrl + 'propertyCategories/');
    }  
}