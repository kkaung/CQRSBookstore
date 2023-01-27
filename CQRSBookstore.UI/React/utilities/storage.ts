export const setItem = (name: string, item: any) => {
    localStorage.setItem(name, JSON.stringify(item));
};

export const getItem = (name: string) => {
    const value = localStorage.getItem(name);

    if (!value) console.error('Unable to get item: ' + name);

    return JSON.parse(value!);
};

export const removeItem = (name: string) => {
    try {
        localStorage.removeItem(name);
    } catch (err) {
        console.error('Unable to remove item: ' + name);
    }
};
