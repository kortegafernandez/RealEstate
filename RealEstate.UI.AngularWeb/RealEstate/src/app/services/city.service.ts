import {HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { City } from '../models/City';

@Injectable()
export class CityService{
    constructor(private http: HttpClient) { }   

    getCities() {
        return this.http.get<City[]>(environment.apiBaseUrl + 'cities/');
    }  
}