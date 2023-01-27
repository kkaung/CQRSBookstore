import React, { ReactNode } from 'react';
import Footer from './Footer';
import Navbar from './Navbar';

type Props = {
    children: ReactNode;
};

export default function Layout({ children }: Props) {
    return (
        <>
            <Navbar />
            <main className='py-5' style={{ minHeight: 'calc(100vh - 56px - 57px)' }} >{children}</main>
            <Footer />
        </>
    );
}
