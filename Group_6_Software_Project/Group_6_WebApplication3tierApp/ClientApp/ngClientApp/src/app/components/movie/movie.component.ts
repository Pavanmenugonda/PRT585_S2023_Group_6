import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/models/movie.model';
import { MoviesService } from 'src/app/services/movies.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.less']
})

export class MovieComponent implements OnInit {
  movies: Movie[] = [];

  constructor(private moviesService: MoviesService) { }

  ngOnInit(): void {
    this.moviesService.getAllMovies().subscribe({
      next: (movies: Movie[] ) => {
        // push movies to this.movies
        this.movies = movies;
        // console.log('movies',this.movies);
        movies.forEach((movie) => {
          console.log(movie.MovieName);
        });
      },
      error: (err) => {
        console.log(err);
      }
    });
    
  }

}
