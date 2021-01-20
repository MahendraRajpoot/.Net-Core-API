import { Component, OnInit } from '@angular/core';
import { Movie } from '../models/movie';
import { MovieserviceService } from '../movieservice.service';
 
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  title = 'All Movies';
  movies: Movie[];
  constructor(private movieService:MovieserviceService) {
    
   }

  ngOnInit() {

    this.movieService.getMovies().subscribe(
      (response:Movie[]) => {
        this.movies = response;
      }
    ); 
  }
}
