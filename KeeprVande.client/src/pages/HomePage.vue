<template>
	<div class="container-fluid bg-white">
			<section class="row mt-3">
			<div class="col-md-3 col-6 my-2" v-for="keep in keeps" :key="keep.id">
					<KeepCard :keepProp="keep"/>
			</div>
			</section>
	</div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { keepsService } from '../services/KeepsService.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';

export default {
	setup() {
			async function getKeeps() {
					try {
							await keepsService.getKeeps();
					}
					catch (error) {
							Pop.error(error.message);
					}
			}
			onMounted(() => {
					getKeeps();
			});
			return {
					keeps: computed(() => AppState.keeps),
			};
	},
	components: { KeepCard }
}
</script>

<style scoped lang="scss">

</style>
