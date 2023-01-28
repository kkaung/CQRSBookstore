import { Layout } from '@/components/common';
import { Book } from '@/types';
import { env } from '@/utilities';
import axios from 'axios';
import { useRouter } from 'next/router';
import React, { useEffect, useState } from 'react';

export default function index() {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [books, setBooks] = useState<Book[] | []>([]);

    const router = useRouter();

    const { q } = router.query;

    useEffect(() => {
        if (!q) return;

        searchBooks(q as string);
    }, [q]);

    const searchBooks = async (query: string) => {
        setIsLoading(true);

        try {
            const res = await axios.get(`${env.API_URI}/api/books?q=${query}`);

            setBooks(res.data);
        } catch (err) {
            console.error('Unable to search books');
        }

        setIsLoading(false);
    };

    return (
        <Layout>
            <div className="container mx-auto">
                {isLoading ? (
                    <div>Searching books...</div>
                ) : (
                    <>
                        {books.length === 0 ? (
                            <div className='text-2xl'>No Search Results. Please try again!</div>
                        ) : (
                            <>
                                <div className='text-2xl mb-3'>Search Result</div>
                                {books.map(book => (
                                    <div
                                        key={book.id}
                                        className="card max-w-[300px] hover:cursor-pointer"
                                        onClick={() =>
                                            router.push(`/books/${book.id}`)
                                        }
                                    >
                                        <div className="card-body">
                                            <h1 className="card-title text-2xl">
                                                {book.title}
                                            </h1>
                                            <div className="card-subittle ">
                                                By {book.author}
                                            </div>
                                        </div>
                                    </div>
                                ))}
                            </>
                        )}
                    </>
                )}
            </div>
        </Layout>
    );
}
