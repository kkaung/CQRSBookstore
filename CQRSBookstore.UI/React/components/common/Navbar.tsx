import { User } from '@/types';
import { env, getItem, removeItem } from '@/utilities';
import Link from 'next/link';
import { useRouter } from 'next/router';
import React, { FormEvent, useEffect, useState } from 'react';
import axios from 'axios';
import jwtDecode from 'jwt-decode';

export default function Navbar() {
    const [isLoading, setIsLoading] = useState(false);
    const [isAuth, setIsAuth] = useState(false);
    const [user, setUser] = useState<null | User>(null);
    const [search, setSearch] = useState('');

    const router = useRouter();

    useEffect(() => {
        const token = getItem('token');

        if (!token) return;

        setIsAuth(true);
        getUser(token);
    }, [isAuth]);

    const handleSubmit = (e: FormEvent) => {
        e.preventDefault();

        router.push('/books?q=' + search);

        setSearch('');
    };

    const handleLogout = () => {
        setIsAuth(false);

        removeItem('token');
    };

    const getUser = async (token: string) => {
        setIsLoading(true);

        try {
            const res = await axios.get(`${env.API_URI}/api/users/me`, {
                headers: { Authorization: 'Bearer ' + token },
            });

            setUser(res.data);
        } catch (err) {
            console.error('Unable to get user');
        }

        setIsLoading(false);
    };

    return (
        <nav className="navbar navbar-expand-lg bg-body-tertiary bg-light">
            <div className="container-fluid">
                <div className="flex items-center">
                    <Link className="navbar-brand" href="/">
                        CQRSBookstore
                    </Link>
                    <form
                        className="flex items-center space-x-4"
                        onSubmit={handleSubmit}
                    >
                        <input
                            className="form-control"
                            placeholder="Search Books..."
                            value={search}
                            onChange={e => setSearch(e.target.value)}
                        />
                        <button type="submit" className="btn btn-primary">
                            Search
                        </button>
                    </form>
                </div>
                <ul className="navbar-nav">
                    <li className="nav-item">
                        <Link href="/" className="nav-link text-dark">
                            Home
                        </Link>
                    </li>
                    {!isAuth ? (
                        <li className="nav-item">
                            <Link href="/login" className="nav-link text-dark">
                                Login
                            </Link>
                        </li>
                    ) : (
                        <>
                            <li className="nav-link text-dark">
                                Welcome {user?.username}
                            </li>
                            <li
                                className="nav-link text-dark cursor-pointer"
                                onClick={handleLogout}
                            >
                                Logout
                            </li>
                        </>
                    )}
                </ul>
            </div>
        </nav>
    );
}
