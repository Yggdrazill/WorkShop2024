import React, { useRef, useState, useEffect } from 'react';
import Item from './Item';

import './App.css';

export default function App(props) {
	const content = useRef();
	const [shoppingCart, setShoppingCart] = useState([]);
	const [items, setItems] = useState([]);
	const [isAdmin, setAdmin] = useState(false);

	const handleBuy = (name, cost) => {
		setShoppingCart([...shoppingCart, { name, cost }]);
	}

	const handleRemove = (index) => {
		const newCart = [...shoppingCart];
		newCart.splice(index, 1);
		setShoppingCart(newCart);
	}

	const handleEditItem = async (id, cost) => {
		console.log(cost);
		const result = await fetch(`https://localhost:7277/Item/${id}`, {
			method: 'PUT',
			headers: { 'Content-Type': 'application/json' },
			body: cost 
		}).catch(err => global.alert(err));

		await fetchData();
	}

	const fetchData = async () => {
		const result = await fetch('https://localhost:7277/Item')
			.then(response => response.json())
			.then(response => setItems(response))
			.catch(err => global.alert(err));

	};


	useEffect(() => {
		

		fetchData();
	}, []);

	const ShoppingApp = () => {
		return (
			<>
				<h3>
					Varor
				</h3>
				{
					items?.map(i => {
						return (
							<div key={i.id}>
								<Item
									id={i.id}
									imageId={i.imageId}
									name={i.name}
									cost={i.cost}
									onBuy={handleBuy} // Här kopplar vi onBuy till funktionen handleBuy.
								/>
							</div>
					)})
				}
				<h3>
					Varukorg
				</h3>
				<p>
					<b>
						Totalt: {shoppingCart.reduce((acc, curr) => { acc += curr.cost; return acc; }, 0)}kr
					</b>
				</p>
				<div>
					{shoppingCart.map((item, index) => (
						<div key={index}>
							<p>
								{item.name} - {item.cost}
								<span style={{ marginLeft: 10, cursor: 'pointer' }} onClick={() => handleRemove(index)}>X</span>
							</p>
						</div>
					))}
				</div>
			</>
		);
	}

	const AdminApp = () => {
		return (
			<>
				<h3>
					Varor
				</h3>
				{items?.map(i => {
					return (
						<div key={i.id}>
							<Item
								id={i.id}
								imageId={i.imageId}
								name={i.name}
								cost={i.cost}
								onEdit={handleEditItem}
							/>
						</div>
				)})}
			</>
		);
	}


	return (
		<div className="App">
			<header className="App-header">
				<div>
					<button className='adminButton' onClick={() => setAdmin(!isAdmin)}>{isAdmin ? 'Gå till shopping' : 'Gå till admin'}</button>
				</div>
				<p>
					Välkommen till min webbshop.
				</p>
				<div
					onClick={() => content.current?.scrollIntoView({ behavior: 'smooth', block: 'start' })}
					className="App-link"
				>
					Börja shoppa
				</div>
			</header>
			<div>
				<div className="App-content" ref={content}>
					{!isAdmin ? <ShoppingApp /> : <AdminApp />}
				</div>
			</div>
		</div>
	);
}

