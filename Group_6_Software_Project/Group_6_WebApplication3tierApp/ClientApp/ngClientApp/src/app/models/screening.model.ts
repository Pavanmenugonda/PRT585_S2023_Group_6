export interface Screening {
    ScreeningId: string;
    MovieID: string;
    Showtime: Date;  
    Price: number;
    AvailableSeats: number;
    IsDeleted: boolean
}