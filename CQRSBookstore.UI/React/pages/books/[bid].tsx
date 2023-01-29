import { Layout } from '@/components/common';
import { Book } from '@/types';
import { env, getItem } from '@/utilities';
import axios from 'axios';
import { useRouter } from 'next/router';
import React, { useEffect, useState } from 'react';
import dayjs from 'dayjs';
import { Modal, Button } from 'react-bootstrap';

export default function BookDetailsPage() {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [isSubmitting, setIsSubmitting] = useState<boolean>(false);
    const [book, setBook] = useState<null | Book>(null);
    const [show, setShow] = useState<boolean>(false);
    const [number, setNumber] = useState<number>(0);
    const [error, setError] = useState<string>('');

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
        setIsSubmitting(true);

        const token = getItem('token');

        // if not signed in, redirect to login page
        if (!token) return router.push('/login');

        try {
            const res = await axios.post(
                `${env.API_URI}/api/books/reservation`,
                { bid: book?.id },
                { headers: { Authorization: 'Bearer ' + token } }
            );

            setNumber(res.data.number);
            setShow(true);
        } catch (err) {
            setError(
                'Unable to reserve as other customer has already reserved this book. Please try another one!'
            );
            console.error('Unable to book ');
        }

        setIsSubmitting(false);
    };

    return (
        <Layout>
            {show && (
                <PopupModal setShow={setShow} show={show} number={number} />
            )}
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
                            disabled={isSubmitting}
                        >
                            Reserve Book
                        </button>
                        {error && (
                            <div className="text-red-500 mt-2">{error}</div>
                        )}
                    </div>
                )}
            </div>
        </Layout>
    );
}

function PopupModal({
    show,
    setShow,
    number,
}: {
    show: boolean;
    setShow: any;
    number: number;
}) {
    const handleClose = () => {
        setShow(false);
    };

    return (
        <Modal show={show}>
            <Modal.Header>
                <Modal.Title>Your Reservation Number</Modal.Title>
            </Modal.Header>
            <Modal.Body className="text-2xl">{number}</Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Close
                </Button>
            </Modal.Footer>
        </Modal>
    );
}
