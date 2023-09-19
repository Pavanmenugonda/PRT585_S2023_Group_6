import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/models/movie.model';
import { MoviesService } from 'src/app/services/movies.service';
import { DialogAction, ActionsLayout } from "@progress/kendo-angular-dialog";
import { Router } from '@angular/router';


@Component({
  selector: 'app-admin-movies',
  templateUrl: './admin-movies.component.html',
  styleUrls: ['./admin-movies.component.less']
})

export class AdminMoviesComponent implements OnInit {
  imageSrc = 'https://lumiere-a.akamaihd.net/v1/images/p_moana_20530_214883e3.jpeg?region=0,0,540,810&width=320'
  imageAlt = 'sample movie'
  movies: Movie[] = [];
  public opened = false;
  public actionsLayout: ActionsLayout = "stretched";
  public layoutOptions: Array<string> = ["start", "center", "end", "stretched"];

  _deleteMovie: Movie = {} as Movie;
  
  constructor(private moviesService: MoviesService, private router: Router) { }

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

  public myActions: DialogAction[] = [
    { text: "No" },
    { text: "Yes", themeColor: "primary" },
  ];

  public onAction(action: DialogAction): void {
    console.log(action.text);
    if (action.text === "Yes") {
      // delete movie
      this.deleteMovie(this._deleteMovie);
      console.log('delete movie');

    }
    this.opened = false;
  }

  public close(status: string): void {
    console.log(status);
    this.opened = false;
  }

  public deleteConfirm(movie: Movie): void {
    console.log(movie);
    this._deleteMovie = movie;
    this.opened = true;
  }
  
  deleteMovie(movie: Movie): void {
    this.moviesService.deleteMovie(movie.MovieId).subscribe({
      next: () => {
        // Update the movies list after deletion
        this.movies = this.movies.filter(m => m.MovieId !== movie.MovieId);
      },
      error: (err) => {
        console.error(err);
      }
    });
  }
  
  gotoEdit(movie: Movie): void {
    console.log(movie);
    this.router.navigate(['admin/movies/edit', movie.MovieId]);
  }
}
