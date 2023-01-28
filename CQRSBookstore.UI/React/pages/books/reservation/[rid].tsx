import { Layout } from '@/components/common';
import { Reservation } from '@/types';
import { env } from '@/utilities';
import axios from 'axios';
import dayjs from 'dayjs';
import { useRouter } from 'next/router';
import React, { useEffect, useState } from 'react';

export default function ReservationPage() {
    const [isLoading, setIsLoading] = useState(false);
    const [reservation, setReservation] = useState<null | Reservation>(null);
    const router = useRouter();

    const { rid } = router.query;

    useEffect(() => {
        if (!rid) return;
        getReservationDetails(rid as string);
    }, [rid]);

    const getReservationDetails = async (query: string) => {
        setIsLoading(true);

        try {
            const res = await axios.get(
                `${env.API_URI}/api/books/reservation/${query}`
            );

            setReservation(res.data);
        } catch (err) {
            console.error('Unable to get reservation details');
        }

        setIsLoading(false);
    };

    return (
        <Layout>
            <div className="container mx-auto">
                {isLoading ? (
                    <div>Loading reservation details...</div>
                ) : (
                    <div>
                        <div>Book Name: {reservation?.book?.title}</div>
                        <div>Reservation Number: {reservation?.number}</div>
                        <div>Reserver: {reservation?.user.username}</div>
                        <div>
                            <span className="mr-1">Reservation Date:</span>
                            {dayjs(reservation?.reservationDate!).format(
                                'DD-MM-YYYY'
                            )}
                        </div>
                        <div>
                            <span className="mr-1">Pickup Date:</span>
                            {dayjs(reservation?.reservationDate!).format(
                                'DD-MM-YYYY'
                            )}
                        </div>
                    </div>
                )}
            </div>
        </Layout>
    );
}
