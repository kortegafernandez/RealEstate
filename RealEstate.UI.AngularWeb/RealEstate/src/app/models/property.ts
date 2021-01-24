import { Address } from "./address";
import { Owner } from "./owner";
import { PropertyCategory } from "./propertyCategory";

export class Property{
    id:number;
    name:string;
    price:number;
    area:number;
    ownerId:number;
    addressId:number;
    categoryId:number;
    firstName:string;
    lastName:string;
    ownerIdentificationNumber:string;
    city:string;
    address1:string;
    address2:string;
    postalCode:string;
    propertyCategory:PropertyCategory;
}