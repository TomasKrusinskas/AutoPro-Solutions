import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CentersComponent } from './centers/centers.component';
import { TechniciansComponent } from './technicians/technicians.component';
import { JobsComponent } from './jobs/jobs.component';
import {HomeComponent} from "./home/home.component";

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'centers', component: CentersComponent },
  { path: 'technicians', component: TechniciansComponent },
  { path: 'jobs', component: JobsComponent },
  // Add more routes as needed
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
