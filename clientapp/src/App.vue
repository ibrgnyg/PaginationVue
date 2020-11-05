<template>
	<div id="app">
		<nav class="navbar navbar-expand-lg navbar-light bg-dark">
			<router-link to="/">
				<a class="navbar-brand">
					<img src="../../clientapp/src/assets/logo.png" width="30" height="30" alt="">
				</a>
			</router-link>


			<div class="collapse navbar-collapse" id="navbarSupportedContent">
				<ul class="navbar-nav mr-auto">
					<router-link tag="li" class-active="active col" to="/" exact>
						<li class="nav-item active">
							<a class="nav-link">Home <span class="sr-only">(current)</span></a>
						</li>
					</router-link>

					<router-link tag="li" class-active="active col" to="/list" exact>
						<li class="nav-item">
							<a class="nav-link">All Users</a>
						</li>
					</router-link>
				</ul>
			</div>
		</nav>

		<router-view/>
	</div>
</template>

<script>


export default {
  name: 'App',

}
</script>

<style>


	nav li.router-link-active,
	nav li.router-link-exact-active {
		background-color: orangered;
		cursor: pointer;
		border-radius:15px;
	}
	

</style>
