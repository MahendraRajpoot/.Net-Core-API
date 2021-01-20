import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutComponent } from './about/about.component'; 
import { ContactComponent } from './contact/contact.component';
import { DashboardComponent } from './dashboard/dashboard.component'; 
import { MovieDetailComponent } from './movie-detail/movie-detail.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { SigninComponent } from './signin/signin.component';
import  { AuthGuard } from '@auth0/auth0-angular'

const routes: Routes = [
  { path: "dashboard", component: DashboardComponent },
  { path: 'signin', component: SigninComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'about', component: AboutComponent }, 
  { path: "movie-detail/:movieID", component: MovieDetailComponent},
  { path: "", redirectTo:"dashboard",pathMatch:"full"},  
  { path: '**', component: NotFoundComponent },   
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
