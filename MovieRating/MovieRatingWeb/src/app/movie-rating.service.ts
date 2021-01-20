import { Injectable } from '@angular/core';
import{HttpClient} from '@angular/common/http'; 
import { Observable } from 'rxjs';
import { MovieRating } from './models/MovieRating';
@Injectable({
  providedIn: 'root'
})
export class MovieRatingService {
  endPoint='http://localhost:52425/movierating/';
  constructor(private http:HttpClient) { }
  
  InsertRating(movieRating: MovieRating) : Observable<MovieRating>
  {
    return this.http.post<MovieRating>(this.endPoint + "InsertRating", movieRating, { responseType: "json" });
  }

}
