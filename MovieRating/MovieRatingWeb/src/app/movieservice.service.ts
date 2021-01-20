import { Injectable } from '@angular/core';
import{HttpClient} from '@angular/common/http';
import { Movie } from './models/movie';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class MovieserviceService {
  endPoint='http://localhost:52425/movie/';
  constructor(private http:HttpClient) { }


  getMovies():Observable<Movie[]>{
    return this.http.get<Movie[]>(this.endPoint+ "getallmovie").pipe();    
  }

  getMovieByID(movieID:string):Observable<Movie>{
    return this.http.get<Movie>(this.endPoint + "GetMovieByID/"+ movieID).pipe();    
  }

}
