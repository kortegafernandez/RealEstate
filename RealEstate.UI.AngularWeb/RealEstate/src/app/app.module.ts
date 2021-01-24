import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PropertyService } from './services/property.service';
import { OwnerService } from './services/owner.service';
import { CityService } from './services/city.service';
import { PropertyCategoryService } from './services/propertyCategory.service';

import { PropertiesComponent } from './components/property/property.component';
import { OwnersComponent } from './components/owner/owner.component';
import { CreatePropertyComponent } from './components/create-property/create-property.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    PropertiesComponent,
    OwnersComponent,
    CreatePropertyComponent,
    AppComponent
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
    BrowserModule,
    FormsModule,  
    HttpClientModule,    
    AppRoutingModule, NgbModule
  ],
  providers: [    
    PropertyService,
    OwnerService,
    CityService,
    PropertyCategoryService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
