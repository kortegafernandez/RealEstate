import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OwnersComponent } from './components/owner/owner.component';
import { PropertiesComponent } from './components/property/property.component';
import { CreatePropertyComponent } from './components/create-property/create-property.component';

const routes: Routes = [
  {
    path: '',
    component: PropertiesComponent,    
  },
  { path: 'properties/create', component: CreatePropertyComponent },
  { path: 'owners', component: OwnersComponent },
  { path: 'properties/edit/:id', component: CreatePropertyComponent},
  
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
