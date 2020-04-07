import React from 'react';

import './styles.css';

export default function top({title, phase}) {
  return(
    <div className="container-topo">
        <p className="title">CAMPEONATO  DE FILMES</p>
        <h3>{title}</h3>
        <p>{phase}</p>
    </div>     
  )
}