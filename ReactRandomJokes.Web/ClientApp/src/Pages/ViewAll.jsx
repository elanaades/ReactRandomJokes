import React, { useState, useEffect } from 'react';
import axios from 'axios';

const ViewAll = () => {

    const [jokes, setJokes] = useState([]);

    useEffect(() => {
        const getJokes = async () => {
            const { data } = await axios.get('/api/jokes/viewall');
            setJokes(data);
        }

        getJokes();
    }, []);

    return (
        <div className="row">
            <div className="col-md-6 offset-md-3">
                {jokes.map(joke => {
                    return (
                        <div key={joke.id} className="card card-body bg-light mb-3">
                            <h5>{joke.setUp}</h5>
                            <h5>{joke.punchLine}</h5>
                            <span>Likes: {joke.userLikedJokes.filter(j => j.liked).length}</span>
                            <br />
                            <span>Dislikes: {joke.userLikedJokes.filter(j => !j.liked).length}</span>
                        </div>
                    )
                })}
            </div>
        </div>
    )
}

export default ViewAll;