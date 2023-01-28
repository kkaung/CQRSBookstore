import { Layout } from '@/components/common';
import { Book } from '@/types';
import { env, getItem } from '@/utilities';
import axios from 'axios';
import { useRouter } from 'next/router';
import React, { useEffect, useState } from 'react';
import dayjs from 'dayjs';

export default function BookDetailsPage() {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [book, setBook] = useState<null | Book>(null);
    const router = useRouter();

    const { bid } = router.query;

    useEffect(() => {
        if (!bid) return;

        getBookDetails(bid as string);
    }, [bid]);

    const getBookDetails = async (bid: string) => {
        setIsLoading(true);

        try {
            const res = await axios.get(`${env.API_URI}/api/books/${bid}`);
            setBook(res.data);
        } catch (err) {
            console.log('Unable to get book details');
        }

        setIsLoading(false);
    };

    const handleReserveBook = async () => {
        const token = getItem('token');

        try {
            const res = axios.post(
                `${env.API_URI}/api/books/${book?.id}/reservation`,
                { headers: { Authorization: 'Bearer ' + token } }
            );
            console.log(res);
        } catch (err) {
            console.log('Unable to get book');
        }
    };

    console.log(new Date(book?.publishedAt!));

    return (
        <Layout>
            <div className="container mx-auto">
                {isLoading ? (
                    <div>Loading Book...</div>
                ) : (
                    <div>
                        <h1 className="display-6">{book?.title}</h1>
                        <div>Author: {book?.title}</div>
                        <div>ISBN: {book?.isbn}</div>
                        <div>
                            Published At:
                            {dayjs(book?.publishedAt!).format('DD-MM-YYYY')}
                        </div>
                        <button
                            className="btn btn-primary mt-3"
                            onClick={handleReserveBook}
                        >
                            Reserve Book
                        </button>
                    </div>
                )}
            </div>
        </Layout>
    );
}
