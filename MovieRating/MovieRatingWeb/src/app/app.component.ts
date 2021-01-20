import { Component,Inject, OnInit } from '@angular/core';
import { Movie } from './models/movie';
import { MovieserviceService } from './movieservice.service';
import { AuthService } from '@auth0/auth0-angular'
import { DOCUMENT } from '@angular/common';

 
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Movie Rating';
  items:Movie[];
  
  constructor(public auth: AuthService, private movieService:MovieserviceService,
    @Inject(DOCUMENT) private doc: Document){

 }
  ngOnInit(){
 
    // console.log("Start calling");
    this.movieService.getMovies().subscribe(response=>{
    this.items = response;  
    });   

 }
 loginWithRedirect() {
  this.auth.loginWithRedirect();
} 
logout() {
  this.auth.logout({ returnTo: this.doc.location.origin });
}
}
