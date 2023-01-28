import { User } from './user';
import { Book } from './book';

export type Reservation = {
    id: string;
    number: number;
    reservationDate: Date;
    pickDate: Date;
    user: User;
    book: Book;
};
