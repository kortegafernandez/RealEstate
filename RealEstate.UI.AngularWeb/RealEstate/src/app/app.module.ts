import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PropertyService } from './services/property.service';
import { OwnerService } from './services/owner.service';

import { PropertiesComponent } from './components/property/property.component';
import { OwnersComponent } from './components/owner/owner.component';
import { CreatePropertyComponent } from './components/create-property/create-property.component';


@NgModule({
  declarations: [
    PropertiesComponent,
    OwnersComponent,
    CreatePropertyComponent,
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,    
    AppRoutingModule
  ],
  providers: [    
    PropertyService,
    OwnerService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
