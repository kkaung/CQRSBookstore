import { Layout } from '@/components/common';
import { env } from '@/utilities';
import axios from 'axios';
import Link from 'next/link';
import { useRouter } from 'next/router';
import React, { FormEvent, useState } from 'react';

export default function RegisterPage() {
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [form, setForm] = useState({
        username: 'John Doe',
        email: 'johndoe123@gmail.com',
        password: 'johndoe',
    });

    const router = useRouter();

    const handleChange = (e: FormEvent) => {
        const target = e.target as HTMLFormElement;
        setForm(prevState => {
            return { ...prevState, [target.name]: target.value };
        });
    };

    const handleSubmit = (e: FormEvent) => {
        e.preventDefault();

        setIsSubmitting(true);

        try {
            axios.post(`${env.API_URI}/public/register`);

            router.push('/');
            setForm({ username: '', email: '', password: '' });
        } catch (err) {
            console.error('Unable to register!');
        }

        setIsSubmitting(false);
    };
    return (
        <Layout>
            <div className="container flex justify-center">
                <form className="card w-[500px]" onSubmit={handleSubmit}>
                    <h3 className="text-center card-header">Register</h3>
                    <div className="card-body">
                        <div className="mb-3">
                            <label htmlFor="username" className="form-label">
                                Username
                            </label>
                            <input
                                type="text"
                                className="form-control"
                                name="username"
                                value={form.username}
                                onChange={handleChange}
                                required
                            />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="email" className="form-label">
                                Email address
                            </label>
                            <input
                                type="email"
                                className="form-control"
                                name="email"
                                value={form.email}
                                onChange={handleChange}
                                required
                            />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="password" className="form-label">
                                Password
                            </label>
                            <input
                                type="password"
                                className="form-control"
                                name="password"
                                value={form.password}
                                onChange={handleChange}
                                required
                            />
                        </div>
                        <div className="space-x-4">
                            <button
                                className="btn btn-primary"
                                type="submit"
                                disabled={isSubmitting}
                            >
                                Submit
                            </button>
                            <Link href="login" className="btn btn-light">
                                Login
                            </Link>
                        </div>
                    </div>
                </form>
            </div>
        </Layout>
    );
}
