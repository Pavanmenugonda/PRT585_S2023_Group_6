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

  imageSrc = 'https://lumiere-a.akamaihd.net/v1/images/p_moana_20530_214883e3.jpeg?region=0,0,540,810&width=320'
  imageAlt = 'sample movie'


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
