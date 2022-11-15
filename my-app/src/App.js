import React, { useRef, useState, useEffect } from 'react';
import Item from './Item';

import './App.css';

export default function App(props) {
	const content = useRef();
	const [totalPrice, setTotalPrice] = useState(0);
	const [orders, setOrders] = useState([]);
	const [items, setItems] = useState([]);
	const [isAdmin, setAdmin] = useState(false);

	const handleBuy = async (item, quantity) => {
		const result = await fetch('https://localhost:7277/order', {
			method: 'POST',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify({ItemId: item.id, Quantity: quantity})
		}).catch(err => global.alert(`Could not fetch from endpoint POST "https://localhost:7277/order" make sure it's implemented. \n Error: ${err}`));
		await fetchOrders();
	}

	const handleRemove = async (id) => {
		const result = await fetch(`https://localhost:7277/Order/${id}`, {
			method: 'DELETE'
		}).catch(err => global.alert(`Could not fetch from endpoint DELETE "https://localhost:7277/order/${id}" make sure it's implemented. \n Error: ${err}`));
		await fetchOrders();
	}

	const handleEditItem = async (id, cost) => {
		console.log(cost);
		const result = await fetch(`https://localhost:7277/Item/${id}`, {
			method: 'PUT',
			headers: { 'Content-Type': 'application/json' },
			body: cost 
		}).catch(err => global.alert(`Could not fetch from endpoint PUT "https://localhost:7277/Item/${id}" make sure it's implemented. \n Error: ${err}`));

		await fetchItems();
	}

	const fetchItems = async () => {
		const result = await fetch('https://localhost:7277/Item')
			.then(response => response.json())
			.then(response => setItems(response))
			.catch(err => global.alert(`Could not fetch from endpoint GET "https://localhost:7277/Item" make sure it's implemented. \n Error: ${err}`));

	};

	const fetchOrders = async () => {
		const result = await fetch('https://localhost:7277/Order')
			.then(response => response.json())
			.then(response => setOrders(response))
			.catch(err => global.alert(`Could not fetch from endpoint GET "https://localhost:7277/Order" make sure it's implemented. \n Error: ${err}`));

	};

	const fetchTotalPrice = async () => {
		const result = await fetch('https://localhost:7277/Cart')
			.then(response => response.json())
			.then(response => setTotalPrice(response))
			.catch(err => global.alert(`Could not fetch from endpoint GET "https://localhost:7277/Cart" make sure it's implemented. \n Error: ${err}`));

	};

	const clearCart = async () => {
		const result = await fetch('https://localhost:7277/Order', {
			method: 'DELETE'
		}).catch(err => global.alert(err));
		await fetchOrders();
	};

	useEffect(() => {
		fetchItems();
		fetchOrders();
	}, []);

	const IconTrashCan = () => (
		<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
			<path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
			<path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
		</svg>
	);

	const ShoppingApp = () => {
		return (
			<>
				<h3>
					Varor
				</h3>
				<div className="itemListWrapper">
					<div className="itemList">
						{items?.map(i => {
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
						)})}
					</div>
				</div>
				<h3>
					Varukorg 
					<input value="Töm" type="button" onClick={clearCart} />
				</h3>
				<p>
					<b>
						Totalt: {totalPrice} kr
					</b>
				</p>
				<div className="orderListWrapper">
					<div className="orderList">
						{orders?.map((order, index) => (
							<div key={index}>
								<p className={"order"}>
									{order.item.name} x {order.quantity} - {order.item.cost * order.quantity}
									<span style={{ marginLeft: 10, cursor: 'pointer' }} onClick={() => handleRemove(order.id)}>{IconTrashCan()}</span>
								</p>
							</div>
						))}
					</div>
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
				<div className="itemList">
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
				</div>
				
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

