import { Component , ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Movie } from 'src/app/models/movie.model';
import { DatePipe } from '@angular/common';

import { MoviesService } from 'src/app/services/movies.service';

@Component({
  selector: 'app-movie-add-edit',
  templateUrl: './movie-add-edit.component.html',
  styleUrls: ['./movie-add-edit.component.less'],
  encapsulation: ViewEncapsulation.None,
  
})
export class MovieAddEditComponent {


  myForm: FormGroup;
  _genres: any[] = [
    "Action",
    "Adventure",
    "Animation",
    "Comedy",
    "Crime",
    "Documentary",
    "Drama",
    "Family",
    "Fantasy",
    "Horror",
    "Mystery",
    "Romance",
    "Science Fiction",
    "Thriller",
    "War",
    "Western",
    "Musical",
    "Historical",
    "Biographical",
    "Superhero",
    "Spy",
    "Disaster",
    "Sports",
    "Psychological",
    "Noir"
  ];

  genresWithTextAndValue : any [] = []

  public value = '';

  public data: any = {
    MovieId: 0,
    MovieName: "",
    Genre: "",
    ReleaseDate: new Date(),
    Description:"",
    // arrivalDate: null,
  };

  constructor(private formBuilder: FormBuilder, private moviesService: MoviesService, private router: Router, private route: ActivatedRoute) { 
    

    // create form
    this.myForm = this.formBuilder.group({
      MovieName: new FormControl(this.data.MovieName, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50),
      ]),
      Genre: new FormControl(this.data.Genre, [
        Validators.required,
      ]),
      ReleaseDate: new FormControl(this.data.ReleaseDate, [
        Validators.required,
      ]),
      Description: new FormControl(this.data.Description, [
        Validators.required,
      ]),
      // arrivalDate: new FormControl(this.data.arrivalDate, [
      //   Validators.required,
      // ]),
    });

    // get movie id from route if exists
    const movieId = this.route.snapshot.paramMap.get('id');
    if (movieId) {
      // Fetch the movie details based on the ID and set the form values
      this.moviesService.getMovie(movieId).subscribe({
        next: (movie) => {
          movie.ReleaseDate = new Date(movie.ReleaseDate);
          this.data = movie;
          console.log('data',this.data);
          this.myForm.patchValue(movie);
        },
        error: (err) => {
          console.error(err);
        }
      });
    }
    
  }

  ngOnInit(): void {
    this.genresWithTextAndValue = this._genres.map(genre => {
      return { text: genre, value: genre.toLowerCase() }; // Assuming value should be lowercase of the genre name
    });
    // this.myForm.patchValue(this.data);
    
    // console.log('data',this.data);
  }

  public submitForm(): void {
    console.log('Log Form', this.myForm.value, this.data.MovieId);
    this.myForm.markAllAsTouched();
    if (this.myForm.valid) {
      console.log("Form Submitted!");
      console.log(this.myForm.value);
      // console.log(this.data);
      // this.data = []
    
      if(this.data.MovieId > 0){
        console.log('updateMovie');
        this.updateMovie();
      }else {
        this.addMovie();
        this.myForm.reset();
      }
    }
  }

  public clearForm(): void {
    this.myForm.reset();
    this.router.navigate(['admin/movies']);
  }

  addMovie(): void {
    console.log('empForm',this.myForm.value);
    this.moviesService.addMovie(this.myForm.value).subscribe({
      next: (movie: any) => {
        console.log("addMovie",movie);
        this.router.navigate(['admin/movies']);
        
        // this.coreService.openSnackBar('Employee added successfully!', 'OK')
      },
      error: (err) => {
        console.log('Error ',err);
      }
    })

  }
  handleFilter(value: string) {
    this.data = this._genres.filter(
      // s.text.toLowerCase() contains value.toLowerCase()
      (s) => s.toLowerCase().indexOf(value.toLowerCase()) !== -1
    );
  }


  updateMovie(): void {
    console.log('updateMovie',this.myForm.value, this.data.MovieId);
    const updatedMovie = this.myForm.value;
    updatedMovie.MovieId = this.data.MovieId;
    updatedMovie.ReleaseDate = '2021-05-05'
    // Get the formatted date
    // const formattedDate = this.datePipe.transform(updatedMovie.ReleaseDate, 'dd-MM-yyyy');
    // Set the formatted date back to the updatedMovie
    // updatedMovie.ReleaseDate = formattedDate;
    this.moviesService.updateMovie(this.data.MovieId, updatedMovie).subscribe({
      next: (movie: any) => {
        console.log("updateMovie",movie);
        this.router.navigate(['admin/movies']);
      
      },
      error: (err) => {
        console.log('Error ',err);
      }
    })

  }
}
