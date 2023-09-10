import { TestBed } from '@angular/core/testing';

import { ScreeningsService } from './screenings.service';

describe('ScreeningsService', () => {
  let service: ScreeningsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ScreeningsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
