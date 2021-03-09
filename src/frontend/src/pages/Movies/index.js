import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';

import api from '../../services/api.services';

import './styles.css';

import Top from '../../components/top'

import loadingGif from '../../assets/loading.gif'

export default function Movies() {
  const history = useHistory();
  const phase = `Selecione 8 filmes que você deseja que entrem na competição
    e depois pressione o botão Gerar Meu Campeonato para prosseguir `;

  const [count, setCount] = useState(0);
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(false);
  const [moviesSelected, setMoviesSelected] = useState([]);

  useEffect(() => {
    sessionStorage.removeItem('result');
    setLoading(true);

    async function loadMovies() {
      let response = await api.get('/movies/get-all');
      setMovies(response.data);
      setLoading(false);
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
    if (moviesSelected.length !== 8) {
      alert('Você deve selecionar apenas 8 filmes para disputar o campeonato')
      return;
    }

    sessionStorage.setItem('result', JSON.stringify(moviesSelected));
    history.push('resultado');
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
          <button onClick={() => handleSubmit()}>Gerar meu campeonato</button>
        </div>
        <div className="container-movies">
          {
            !loading ? <ul className="list-movies">
              {
                (movies || []).map((movie) => (
                  <li className="movies-item" key={movie.id}>
                    <label className="container-check">
                      <input type="checkbox" data-testid={movie.id} value={movie.id} onChange={(e) => handleChange(e)} className="disable-checkbox" />
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
              : <img src={loadingGif} className="loading" alt="loading" />}
        </div>
      </div>
    </>
  )
}