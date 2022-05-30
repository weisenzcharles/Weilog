package org.charles.weilog.repository;

import org.charles.weilog.domain.Taxonomy;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

/**
 * 标签数据仓库。
 *
 * @author Charles
 */
public interface CategoryRepository extends JpaRepository<Taxonomy, Long>, JpaSpecificationExecutor<Taxonomy> {
}
