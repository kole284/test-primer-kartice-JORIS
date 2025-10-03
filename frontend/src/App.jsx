
import React, { useEffect, useState } from 'react';
import BookCard from './components/BookCard';
import AddBookPopup from './components/AddBookPopup';
import './App.css';

function App() {
  const [knjige, setKnjige] = useState([]);
  const [showPopup, setShowPopup] = useState(false);
  {/*komentar za main*/ }


  {/*Ovo se koristi za hvatanje podataka i ucitavanje podataka u kartice*/}
  useEffect(() => {
    fetch('http://localhost:5240/api/knjige')
      .then(res => res.json())
      .then(data => setKnjige(data));
  }, []);

  const handleAddBook = (book) => {
    fetch('http://localhost:5240/api/knjige', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(book)
    })
      .then(res => res.json())
      .then(newBook => setKnjige([...knjige, newBook]));
  };{/*komentarar dodajKnjigu
    */}

  const handleBuyBook = (id) => {
    fetch(`http://localhost:5240/api/knjige/${id}/kupi`, {
      method: 'POST'
    })
      .then(res => {
        if (!res.ok) throw new Error('Nema na stanju');
        return res.json();
      })
      .then(updatedBook => {
        setKnjige(knjige.map(k => k.id === id ? updatedBook : k));
      })
      .catch(err => alert(err.message));{/*komentarar*/}
  };

  return (
    <div className="app-container">
      <h1>Knjige</h1>
      <button onClick={() => setShowPopup(true)}>Dodaj knjigu</button>
      <div className="book-list">
        {knjige.map(knjiga => (
          <BookCard key={knjiga.id} knjiga={knjiga} onBuy={handleBuyBook} />
        ))}
      </div>
      {showPopup && <AddBookPopup onClose={() => setShowPopup(false)} onAdd={handleAddBook} />}
    </div>
  );
}

export default App;
