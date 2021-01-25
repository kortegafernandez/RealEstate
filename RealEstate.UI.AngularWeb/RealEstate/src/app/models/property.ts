import { Address } from "./address";
import { Owner } from "./owner";
import { PropertyCategory } from "./propertyCategory";

export class Property{
    id:number;
    name:string;
    price:number;
    area:number;
    ownerId:number;
    cityId:number;
    addressId:number;
    categoryId:number;
    owner:Owner;
    city:string;
    address1:string;
    address2:string;
    postalCode:string;
    propertyCategory:PropertyCategory;
}