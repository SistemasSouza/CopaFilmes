import React, { useEffect, useState } from 'react';

import api from '../../services/api.services';
import './styles.css';

import Top from '../../components/top';

export default function Results({history}) {

    const phase = "Veja o resultado final do campeonato de filmes de forma simples e rápida";

    const [result, setResult] = useState([]);

    useEffect(() => {
      let moviesSelected = JSON.parse(sessionStorage.getItem('result'));

      api.post('movies/finish-result', moviesSelected).then(response => {

      setResult(response.data);
      
      }).catch(_ => {
        alert('Houve um erro ao gerar o campeonato');
        history.push('/')
      })
    }, [history])

    return (
        <>
            <Top title="Resultado Final" phase={phase} />
            <div className="container">
                <ul className="result-list-movies">
                    {
                        (result || []).map((movie, index) => (
                            <li className="result-movies-item" key={movie.id}>
                                <span>{index + 1}°</span>  {movie.titulo}
                            </li>
                        ))
                    }
                </ul>
            </div>
        </>
    )
}