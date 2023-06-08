import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useAuthDataContext } from '../AuthContext';
import { Link } from 'react-router-dom';

const Home = () => {
    const { user } = useAuthDataContext();
    const isLoggedIn = !!user;

    const [joke, setJoke] = useState({
        id: '',
        setUp: '',
        punchLine: '',
        likes: '',
        dislikes: ''
    });
    const [userInteractionStatus, setUserInteractionStatus] = useState('');

    useEffect(() => {
        const getRandomJoke = async () => {
            const { data } = await axios.get('/api/jokes/getrandomjoke');
            const { data: interactionStatus } = await axios.get(`/api/jokes/getinteractionstatus/${data.id}`);
            setJoke(data);
            setUserInteractionStatus(interactionStatus.status);
        }

        getRandomJoke();
    }, []);


    const onButtonClick = () => {
        window.location.reload();
    }

    const interactWithJoke = async like => {
        const { id } = joke;
        await axios.post(`/api/jokes/interactwithjoke`, { jokeId: id, like });
        const { data: interactionStatus } = await axios.get(`/api/jokes/getinteractionstatus/${id}`);
        setUserInteractionStatus(interactionStatus.status);
    }

    const canLike = userInteractionStatus !== 'Liked' && userInteractionStatus !== 'CanNoLongerInteract';
    const canDislike = userInteractionStatus !== 'Disliked' && userInteractionStatus !== 'CanNoLongerInteract';
    return (
        <div className="row" style={{ minHeight: '80vh', display: 'flex', alignItems: 'center' }}>
            <div className="col-md-6 offset-md-3 bg-light p-4 rounded shadow">
                {joke.setUp && < div >
                    <h4>{joke.setUp}</h4>
                    <h4>{joke.punchLine}</h4>
                    <div>
                        {userInteractionStatus !== 'Unauthenticated' && <div>
                            <button disabled={!canLike} onClick={() => interactWithJoke(true)}
                                className="btn btn-primary">Like
                            </button>
                            <button disabled={!canDislike} onClick={() => interactWithJoke(false)}
                                className="btn btn-danger">Dislike
                            </button>
                        </div>}
                        {userInteractionStatus === 'Unauthenticated' && <div>
                            <Link to='/Login'>Login to your account to like/dislike this joke</Link>
                        </div>}
                        <br />
                        <h4>Likes: {joke.likes}</h4>
                        <h4>Dislikes: {joke.dislikes}</h4>
                        <h4>
                            <button className="btn btn-link" onClick={onButtonClick}>Refresh</button>
                        </h4>
                    </div>
                </div>}
                {!joke.setUp && <h3>Loading...</h3>}
            </div>
        </div>
    )



}

export default Home;