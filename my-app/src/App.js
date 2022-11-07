import React, { useRef, useState, useEffect } from 'react';
import Item from './Item';

import './App.css';

export default function App(props) {
	const content = useRef();
	const [shoppingCart, setShoppingCart] = useState([]);
	const [items, setItems] = useState([]);
	const [isAdmin, setAdmin] = useState(false);

	const handleBuy = async (item, quantity) => {
		const result = await fetch('https://localhost:7277/Cart/order', {
			method: 'POST',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify({ItemId: item.id, Quantity: quantity})
		}).catch(err => global.alert(err));
		await fetchCart();
	}

	const handleRemove = async (id) => {
		const result = await fetch(`https://localhost:7277/Cart/order/${id}`, {
			method: 'DELETE'
		}).catch(err => global.alert(err));
		await fetchCart();
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

	const fetchCart = async () => {
		const result = await fetch('https://localhost:7277/Cart')
			.then(response => response.json())
			.then(response => setShoppingCart(response))
			.catch(err => global.alert(err));

	};

	const clearCart = async () => {
		const result = await fetch('https://localhost:7277/Cart', {
			method: 'DELETE'
		}).catch(err => global.alert(err));
		await fetchCart();
	};

	useEffect(() => {
		fetchData();
		fetchCart();
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
									onBuy={() => handleBuy(i, 1)}
								/>
							</div>
					)})
				}
				<h3>
					Varukorg 
					<input value="Töm" type="button" onClick={clearCart} />
				</h3>
				<p>
					<b>
						Totalt: {shoppingCart?.totalPrice} kr
					</b>
				</p>
				<div>
					{shoppingCart?.cartItems?.map((item, index) => (
						<div key={index}>
							<p>
								{item.name} - {item.cost}
								<span style={{ marginLeft: 10, cursor: 'pointer' }} onClick={() => handleRemove(item.id)}>X</span>
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

