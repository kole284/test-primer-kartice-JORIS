import React from 'react';
import './BookCard.css';

export default function BookCard({ knjiga, onBuy }) {
  return (
    <div className="book-card">
      <img src={knjiga.slikaUrl} alt={knjiga.naslov} style={{ width: '150px', height: '200px', objectFit: 'cover' }} />
      <h3>{knjiga.naslov}</h3>
      <p><b>Autor:</b> {knjiga.autor}</p>
      <p><b>Zanr:</b> {knjiga.zanr}</p>
      <p><b>Opis:</b> {knjiga.opis}</p>
      <p><b>Cena:</b> {knjiga.cena} RSD</p>
      <p><b>Na stanju:</b> {knjiga.kolicinaNaStanju}</p>
      <button onClick={() => onBuy(knjiga.id)} disabled={knjiga.kolicinaNaStanju <= 0}>
        Kupi
      </button>
    </div>
  );
}
