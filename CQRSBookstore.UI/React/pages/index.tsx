import { Layout } from '@/components/common';
import axios from 'axios';
import { FormEvent, useEffect, useState } from 'react';
import { env } from '@/utilities';
import { Book } from '@/types';
import Link from 'next/link';
import { useRouter } from 'next/router';

export default function Home() {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [books, setBooks] = useState<Book[] | []>([]);
    const [number, setNumber] = useState<string>('');

    const router = useRouter();

    useEffect(() => {
        getBooks();
    }, []);

    const getBooks = async () => {
        setIsLoading(true);

        try {
            const res = await axios.get(`${env.API_URI}/api/books`);
            setBooks(res.data);
        } catch (err) {
            console.error('Unable to get books!');
        }

        setIsLoading(false);
    };

    const handleCheck = (e: FormEvent) => {
        e.preventDefault();
        router.push(`/books/reservation/${number}`);
    };

    return (
        <Layout>
            <div className="container mx-auto">
                <header className="text-center">
                    <h1 className="display-5">Welcome To CQRS Bookstore</h1>
                    <h2 className="display-6">
                        The first leading bookstore in Australia
                    </h2>
                </header>
                <form
                    className="mt-12  flex items-center space-x-4"
                    onSubmit={handleCheck}
                >
                    <input
                        className="form-control max-w-[200px]"
                        placeholder="Reservation Number..."
                        required
                        value={number}
                        onChange={e => setNumber(e.target.value)}
                    />
                    <button type="submit" className="btn btn-primary">
                        Check
                    </button>
                </form>
                <div className="mt-4">
                    {isLoading ? (
                        <div>Loading books...</div>
                    ) : (
                        <div className="flex flex-wrap space-x-4">
                            {books.map((book: Book) => (
                                <div className="card" key={book.id}>
                                    <div className="card-body">
                                        <Link
                                            href={`books/${book.id}`}
                                            className=""
                                        >
                                            <h5 className="card-title">
                                                {book.title}
                                            </h5>
                                        </Link>
                                        <h6 className="card-subtitle mb-2 text-muted">
                                            Author: {book.author}
                                        </h6>
                                        <div className="text-secondary text-sm">
                                            ISBN: {book.isbn}
                                        </div>
                                    </div>
                                </div>
                            ))}
                        </div>
                    )}
                </div>
            </div>
        </Layout>
    );
}
