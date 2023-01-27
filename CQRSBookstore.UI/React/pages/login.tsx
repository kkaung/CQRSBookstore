import { Layout } from '@/components/common';
import { env, setItem } from '@/utilities';
import axios from 'axios';
import Link from 'next/link';
import { useRouter } from 'next/router';
import React, { FormEvent, useState } from 'react';

export default function LoginPage() {
    const [form, setForm] = useState({
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

    const handleSubmit = async (e: FormEvent) => {
        e.preventDefault();

        try {
            const res = await axios.post(`${env.API_URI}/public/login`, form);

            // store the token in local storage
            setItem('token', res.data.token);

            router.push('/');
        } catch (err) {
            console.error('Unable to submit!');
        }
    };

    return (
        <Layout>
            <div className="container flex justify-center">
                <form className="card w-[500px]" onSubmit={handleSubmit}>
                    <h3 className="text-center card-header">Login</h3>
                    <div className="card-body">
                        <div className="mb-3">
                            <label htmlFor="email" className="form-label">
                                Email
                            </label>
                            <input
                                type="email"
                                name="email"
                                className="form-control"
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
                                name="password"
                                className="form-control"
                                value={form.password}
                                onChange={handleChange}
                                required
                            />
                        </div>
                        <div className="mb-3 form-check">
                            <input
                                type="checkbox"
                                className="form-check-input"
                            />
                            <label className="form-check-label" htmlFor="check">
                                Remember me!
                            </label>
                        </div>
                        <div className="space-x-4">
                            <input
                                type="submit"
                                value="Submit"
                                className="btn btn-primary"
                            />
                            <Link href="register" className="btn btn-light">
                                Register
                            </Link>
                        </div>
                    </div>
                </form>
            </div>
        </Layout>
    );
}
