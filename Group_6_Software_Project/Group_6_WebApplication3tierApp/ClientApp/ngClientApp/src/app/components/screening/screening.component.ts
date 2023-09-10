import { Component, OnInit } from '@angular/core';
import { Screening } from 'src/app/models/screening.model';
import { ScreeningService } from 'src/app/services/screenings.service';

@Component({
  selector: 'app-screening',
  templateUrl: './screening.component.html',
  styleUrls: ['./screening.component.less']
})

export class ScreeningComponent implements OnInit{
  screenings: Screening[] = [];

  constructor(private screeningService: ScreeningService) { }

  ngOnInit(): void {
    this.screeningService.getAllScreening().subscribe({
      next: (screenings: Screening[] ) => {
  
        this.screenings = screenings;
        
      },
      error: (err) => {
        console.log(err);
      }
    });
    
  }
}
