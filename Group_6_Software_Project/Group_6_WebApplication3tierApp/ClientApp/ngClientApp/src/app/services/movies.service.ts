import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movie } from '../models/movie.model';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  constructor(private http: HttpClient) { }
  baseUrl: string = environment.baseUrl;

  getAllMovies(): Observable<Movie[]>{
    return this.http.get<Movie[]>(this.baseUrl + '/api/Movie')
  }

  addMovie(addMovieRequest: Movie): Observable<Movie> {
    
    return this.http.post<Movie>(this.baseUrl + '/api/Movie', addMovieRequest);

  }

  getMovie(id: string): Observable<Movie> {
    
    return this.http.get<Movie>(this.baseUrl + '/api/Movie/' + id);

  }

  updateMovie(id: string, editMovieRequest: Movie): Observable<Movie> {
    
    return this.http.put<Movie>(this.baseUrl + '/api/Movies/' + id, editMovieRequest);

  }
  
  deleteMovie(id: string): Observable<Movie> {
    
    return this.http.delete<Movie>(this.baseUrl + '/api/Movies/' + id);

  }
}
