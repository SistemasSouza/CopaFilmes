import React, { useState, useEffect } from 'react';

import api from '../../services/api.services';

import './styles.css';

import Top from '../../components/top'

export default function Teams({ history }) {
    const phase = `Selecione 8 filmes que você deseja que entrem na competição
    e depois pressione o botão Gerar Meu Campeonato para prosseguir `;

    const [count, setCount] = useState(0);
    const [movies, setMovies] = useState([]);
    const [moviesSelected, setMoviesSelected] = useState([]);

    useEffect(() => {
        sessionStorage.removeItem('result');

        async function loadMovies() {
            let response = await api.get('/movies/obter-todos-filmes');
            setMovies(response.data);
        }

        loadMovies();
    }, [])

    function handleChange(e) {
        let isChecked = e.target.checked;

        if (isChecked)
            setCount(count + 1)
        else
            setCount(count - 1)

        toogleMoviesSelected(e.target.value, isChecked)
    }

    function handleSubmit() {
        api.post('movies/resultado-final', moviesSelected).then(response => {
            
          setMoviesSelected([]);
          sessionStorage.setItem('result', JSON.stringify(response.data));
          history.push('resultado');
        }).catch(_ => {
          setMoviesSelected([]);
          alert('Houve um erro ao gerar o campeonato');
        })
    }

    function toogleMoviesSelected(idMovie, isChecked) {

        let newMoviesSelected = [...moviesSelected];

        if (isChecked) {
            let movie = movies.find((elem) => elem.id === idMovie);
            newMoviesSelected.push(movie)
        }
        else {
            moviesSelected.filter((elem) => {
                if (elem.id === idMovie) {
                    newMoviesSelected.splice(newMoviesSelected.indexOf(idMovie), 1)
                }
                return 0;
            })
        }
        setMoviesSelected(newMoviesSelected)
    }

    return (
        <>
            <Top title="Fase de Seleção" phase={phase} />
            <div className="container">
                <div className="actions">
                    <div className="count">Selecionados <br /> {count} de 8 filmes</div>
                    <button className={count === 8 ? "" : "btn-disabled"} onClick={() => handleSubmit()}>Gerar meu campeonato</button>
                </div>
                <div className="container-movies">
                    <ul className="list-movies">
                        {
                            (movies || []).map((movie) => (
                                <li className="movies-item" key={movie.id}>
                                    <label className="container-check">
                                        <input type="checkbox" value={movie.id} onChange={(e) => handleChange(e)} />
                                        <span className="checkmark"></span>
                                    </label>
                                    <div className="info-movie">
                                        <p>{movie.titulo}</p>
                                        <span>{movie.ano}</span>
                                    </div>
                                </li>
                            ))
                        }
                    </ul>
                </div>
            </div>
        </>
    )
}