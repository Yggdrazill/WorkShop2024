import React, { useRef, useState, useEffect } from 'react';
import Item from './Item';

import IconBitcoin from './bitcoin.png';
import IconRtx from './rtx.png';
import IconRc from './revell.jpeg';
import IconAoE4 from './aoe4.png';
import IconStiga from './stiga.jpeg';

import './App.css';
 
export default function App(props) {
	const content = useRef();
	const [shoppingCart, setShoppingCart] = useState([]);
	const [funStuff, setFunStuff] = useState(false);
	const [items, setItems] = useState([]);

	const handleBuy = (name, cost) => {
		if (name === 'Revell RC') {
			setFunStuff(true);
		}
		setShoppingCart([...shoppingCart, { name, cost }]);
	}

	const handleRemove = (index) => {
		const newCart = [...shoppingCart];
		newCart.splice(index, 1);
		setShoppingCart(newCart);
	}

	useEffect(() => {
		const fetchData = async () => {
			const result = await fetch('Item', {
				method: 'GET'
			})
			.then(response => response.json())
			.then(response => {
    			console.log(response)
			});
			console.log(result);
			setItems(result.data);
		};

		fetchData();
	}, []);


	return (
		<div className="App">
			<header className="App-header">
				<p>
					Välkommen till min webbshop. {items?.join(',')}
				</p>
				<div
					onClick={() => content.current?.scrollIntoView({ behavior: 'smooth', block: 'start' })}
					className="App-link"
				>
					Börja shoppa
				</div>
			</header>
			<div className="App-content" ref={content}>
				<h3>
					Varor
				</h3>
				<Item
					name='Age of Empires IV'
					cost={600}
					icon={IconAoE4}
					onBuy={handleBuy} // Här kopplar vi onBuy till funktionen handleBuy.
				/>
				<Item
					name='Stiga AXE Padel Racket'
					cost={2300}
					icon={IconStiga}
					onBuy={handleBuy} // Här kopplar vi onBuy till funktionen handleBuy.
				/>
				<Item
					name='Bitcoin'
					cost={500000}
					sale={450000}
					icon={IconBitcoin}
					onBuy={handleBuy} // Här kopplar vi onBuy till funktionen handleBuy.
				/>
				<Item
					name='GeForce RTX 3090'
					cost={20000}
					icon={IconRtx}
					onBuy={handleBuy} // Här kopplar vi onBuy till funktionen handleBuy.
				/>
				<Item
					name='Revell RC'
					cost={500}
					icon={IconRc}
					onBuy={handleBuy} // Här kopplar vi onBuy till funktionen handleBuy.
					funStuff={funStuff}
				/>
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
			</div>
		</div>
	);
}

