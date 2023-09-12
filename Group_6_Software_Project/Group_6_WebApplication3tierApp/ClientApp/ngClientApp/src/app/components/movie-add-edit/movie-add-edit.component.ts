import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { MoviesService } from 'src/app/services/movies.service';

@Component({
  selector: 'app-movie-add-edit',
  templateUrl: './movie-add-edit.component.html',
  styleUrls: ['./movie-add-edit.component.less']
})
export class MovieAddEditComponent {
  form: FormGroup;
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
    MovieID: 0,
    MovieName: "",
    Genre: "",
    ReleaseDate: "",
    Description:""
  };

  constructor(private formBuilder: FormBuilder, private moviesService: MoviesService, private router: Router) { 
    // create form
    this.form = this.formBuilder.group({
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
      
    });
    
  }

  ngOnInit(): void {
    this.genresWithTextAndValue = this._genres.map(genre => {
      return { text: genre, value: genre.toLowerCase() }; // Assuming value should be lowercase of the genre name
    });
    this.form.patchValue(this.data);
    console.log(this.data);
  }

  public submitForm(): void {
    console.log('Log Form', this.form.value);
    this.form.markAllAsTouched();
    if (this.form.valid) {
      console.log("Form Submitted!");
      console.log(this.form.value);
      // console.log(this.data);
      // this.data = []
       this.addMovie();
      this.form.reset();
    }
  }
  public clearForm(): void {
    this.form.reset();
  }

  addMovie(): void {
    console.log('empForm',this.form.value);
    this.moviesService.addMovie(this.form.value).subscribe({
      next: (movie: any) => {
        console.log("addMovie",movie);
        this.router.navigate(['movie']);
        
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
}
