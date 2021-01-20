import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from '../models/movie';
import { MovieRating } from '../models/MovieRating';
import { MovieRatingService } from '../movie-rating.service';
import { MovieserviceService } from '../movieservice.service'; 
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit { 
  movieID: string;
  movieName : string;
  releaseDate: Date;
  movie: Movie;
  avarageRating:number;
  description:string;
   constructor(private actRoute: ActivatedRoute,private movieService:MovieserviceService, private movieRating : MovieRatingService,
    private _router: Router ) {
    this.movieID = this.actRoute.snapshot.params.movieID; 
  }

  ngOnInit() {
    this.movieService.getMovieByID(this.movieID).subscribe(
      (response:Movie) => {
        if(response != undefined){ 
        this.movie = response;
        this.movieID  = this.movie.movieID.toString();
        this.movieName  = this.movie.movieName;
        this.releaseDate  = this.movie.releaseDate;
        this.avarageRating = this.movie.averageRating;
        this.description =this.movie.description;
        }
        else{
          this._router.navigateByUrl('/404');
        } 
      }
    ); 
  }
  onRateClick(event, rating: number){ 
    var movieRating: MovieRating = new MovieRating();
    movieRating.movieID = Number(this.movieID);
    movieRating.rating = rating;
    movieRating.createdBy = 1;  
    this.movieRating.InsertRating(movieRating).subscribe(
      (response) => {
        console.log("Rating added");
      }
    );   
  }

  public onRating(rating : number): void {
    var movieRating: MovieRating = new MovieRating();
    movieRating.movieID = Number(this.movieID);
    movieRating.rating = rating;
    movieRating.createdBy = 1;  
    this.movieRating.InsertRating(movieRating).subscribe(
      (response) => {
        console.log("Rating added");
      }
    );
  }

  onRateHover(event, rating: number){ 
    for (let i = 0; i < rating; i++) {
      console.log ("Block statement execution no." + i);
    }
  }
}
