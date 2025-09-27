import React, { useState } from 'react';
import './AddBookPopup.css';

export default function AddBookPopup({ onClose, onAdd }) {
  const [form, setForm] = useState({
    naslov: '', autor: '', zanr: '', datumIzdavanja: '', opis: '',
    slikaUrl: '', brojStranica: '', jezik: '', izdavac: '', cena: '', kolicinaNaStanju: ''
  });

  const handleChange = e => setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = e => {
    e.preventDefault();
    onAdd(form);
    onClose();
  };

  return (
    <div className="popup-overlay">
      <div className="popup">
        <form onSubmit={handleSubmit} className="popup-form">
          <h2>Dodaj knjigu</h2>
          <input
            name="naslov"
            placeholder="Naslov"
            value={form.naslov}
            onChange={handleChange}
            required
          />
          <input
            name="autor"
            placeholder="Autor"
            value={form.autor}
            onChange={handleChange}
            required
          />
          <input
            name="zanr"
            placeholder="Žanr"
            value={form.zanr}
            onChange={handleChange}
            required
          />
          <input
            type="date"
            name="datumIzdavanja"
            placeholder="Datum izdavanja"
            value={form.datumIzdavanja}
            onChange={handleChange}
            required
          />
          <input
            name="opis"
            placeholder="Opis"
            value={form.opis}
            onChange={handleChange}
          />
          <input
            name="slikaUrl"
            placeholder="Slika URL (npr. /images/prokleta_avlija.jpg)"
            value={form.slikaUrl}
            onChange={handleChange}
          />
          <input
            type="number"
            name="brojStranica"
            placeholder="Broj stranica"
            value={form.brojStranica}
            onChange={handleChange}
            required
            min={1}
          />
          <input
            name="jezik"
            placeholder="Jezik"
            value={form.jezik}
            onChange={handleChange}
            required
          />
          <input
            name="izdavac"
            placeholder="Izdavač"
            value={form.izdavac}
            onChange={handleChange}
            required
          />
          <input
            type="number"
            name="cena"
            placeholder="Cena"
            value={form.cena}
            onChange={handleChange}
            required
            min={0}
          />
          <input
            type="number"
            name="kolicinaNaStanju"
            placeholder="Količina na stanju"
            value={form.kolicinaNaStanju}
            onChange={handleChange}
            required
            min={0}
          />
          <div className="popup-buttons">
            <button type="submit">Dodaj</button>
            <button type="button" onClick={onClose}>Zatvori</button>
          </div>
        </form>
      </div>
    </div>
  );
}
